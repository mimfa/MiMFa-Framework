using MiMFa_Framework.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MiMFa_Framework.Network.UDP
{
    public class MiMFa_Receiver : TCP.MiMFa_Receiver
    {
        public override TransportType TransType { get; set; } = TransportType.Udp;
        public override ProtocolType ProtType { get; set; }= ProtocolType.Udp;
    }
}