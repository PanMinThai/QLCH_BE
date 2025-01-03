using AutoMapper.Internal;
using QLCH_BE.Modal;

namespace QLCH_BE.Service
{
    public interface IEmailService
    {
        Task SendEmail(Mailrequest mailrequest);
    }
}
