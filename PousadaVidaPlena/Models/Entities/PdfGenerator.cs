using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using PousadaVidaPlena.Models;
using System.Globalization;
using System.IO;

public class PdfGenerator
{
    public static byte[] GenerateReservationPdf(Reservation reservation)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            // Crie um documento PDF
            using (PdfDocument pdf = new PdfDocument())
            {
                // Adicione uma página ao documento
                PdfPage page = pdf.AddPage();

                // Configure o formato da página
                page.Size = PdfSharpCore.PageSize.A4;
                page.Orientation = PdfSharpCore.PageOrientation.Portrait;

                // Crie um objeto XGraphics para desenhar na página
                using (XGraphics gfx = XGraphics.FromPdfPage(page))
                {
                    // Defina as fontes
                    XFont titleFontPrinc = new XFont("Arial", 20, XFontStyle.Bold);
                    XFont titleFont = new XFont("Arial", 16, XFontStyle.Bold);
                    XFont normalFont = new XFont("Arial", 12);

                    // Adicione o título do documento
                    gfx.DrawString("Pousada Vida Plena", titleFontPrinc, XBrushes.Black, new XRect(10, 10, page.Width, 20), XStringFormats.TopLeft);
                    gfx.DrawString("Recibo de Reserva", titleFont, XBrushes.Black, new XRect(10, 40, page.Width, 20), XStringFormats.TopLeft);

                    // Adicione os detalhes da reserva
                    gfx.DrawString($"Número da Reserva: #{reservation.NrReservation}", normalFont, XBrushes.Black, new XRect(10, 70, page.Width, 20), XStringFormats.TopLeft);
                    gfx.DrawString($"Data da Reserva: {DateTime.Now.ToString("dd/MM/yyyy")}", normalFont, XBrushes.Black, new XRect(10, 90, page.Width, 20), XStringFormats.TopLeft);
                    gfx.DrawString($"Cliente: {reservation.Client.Name}", normalFont, XBrushes.Black, new XRect(10, 110, page.Width, 20), XStringFormats.TopLeft);
                    gfx.DrawString($"CPF: {reservation.Client.Cpf}", normalFont, XBrushes.Black, new XRect(10, 130, page.Width, 20), XStringFormats.TopLeft);
                    gfx.DrawString($"Numero Do Quarto: {reservation.Room.RoomNumber}", normalFont, XBrushes.Black, new XRect(10, 150, page.Width, 20), XStringFormats.TopLeft);
                    gfx.DrawString($"Tipo Do Quarto: {reservation.Room.Type}", normalFont, XBrushes.Black, new XRect(10, 170, page.Width, 20), XStringFormats.TopLeft);
                    gfx.DrawString($"Data de CheckIn: {reservation.CheckInDate}", normalFont, XBrushes.Black, new XRect(10, 190, page.Width, 20), XStringFormats.TopLeft);
                    gfx.DrawString($"Data de ChekOut: {reservation.CheckOutDate}", normalFont, XBrushes.Black, new XRect(10, 210, page.Width, 20), XStringFormats.TopLeft);
                    gfx.DrawString($"Status da Reserva: {reservation.ReservationStatus}", normalFont, XBrushes.Black, new XRect(10, 230, page.Width, 20), XStringFormats.TopLeft);
                    gfx.DrawString($"Valor Total: R${reservation.ReservationAmount.ToString("F2", CultureInfo.InvariantCulture)}", normalFont, XBrushes.Black, new XRect(10, 250, page.Width, 20), XStringFormats.TopLeft);
                    gfx.DrawString($"Observações: {reservation.Observations}", normalFont, XBrushes.Black, new XRect(10, 270, page.Width, 20), XStringFormats.TopLeft);


                    // Adicione mais detalhes conforme necessário
                    gfx.DrawString($"Data do Recibo: {DateTime.Now.ToString("dd/MM/yyyy")}", normalFont, XBrushes.Black, new XRect(10, page.Height - 30, page.Width, 20), XStringFormats.TopLeft);

                    // Adicione as linhas para assinatura
                    gfx.DrawString("_______________________", normalFont, XBrushes.Black, new XRect(page.Width / 2 - 120, page.Height - 60, page.Width, 20), XStringFormats.TopLeft);
                    gfx.DrawString("Cliente: " + reservation.Client.Name, normalFont, XBrushes.Black, new XRect(page.Width / 2 - 120, page.Height - 40, page.Width, 20), XStringFormats.TopLeft);


                    gfx.DrawString("_______________________", normalFont, XBrushes.Black, new XRect(page.Width / 2 + 80, page.Height - 60, page.Width, 20), XStringFormats.TopLeft);
                    gfx.DrawString("Funcionário: " + reservation.Employee.Name, normalFont, XBrushes.Black, new XRect(page.Width / 2 + 80, page.Height - 40, page.Width, 60), XStringFormats.TopLeft);


                    // Salve o documento PDF no stream de memória
                    pdf.Save(stream);
                }
            }

            // Retorne o array de bytes do stream de memória
            return stream.ToArray();
        }
    }
}
