using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Net.WebSockets;
using System.Net;


namespace IT3B_Chat.Server
{
    public class Server
    {
        private HttpListener listener;

        public Server(string url)
        {
            listener = new HttpListener();
            listener.Prefixes.Add(url);
        }

        public async Task Start()
        {
            listener.Start();
            Console.WriteLine($"Server listening at {listener.Prefixes}");
            while (true)
            {
                var context = await listener.GetContextAsync();
                if (context.Request.IsWebSocketRequest)
                {
                    await ProcessWebSocketRequest(context);
                }
                else
                {
                    context.Response.StatusCode = 400;
                    context.Response.Close();
                }
            }
        }

        private async Task ProcessWebSocketRequest(HttpListenerContext context)
        {
            var webSocketContext = await context.AcceptWebSocketAsync(null);
            var webSocket = webSocketContext.WebSocket;

            byte[] buffer = new byte[1024];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            while (!result.CloseStatus.HasValue)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                Console.WriteLine($"Received message: {message}");

                // Echo message back to the client
                await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, result.Count), result.MessageType, result.EndOfMessage, CancellationToken.None);

                buffer = new byte[1024];
                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }

            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }
    }
}
