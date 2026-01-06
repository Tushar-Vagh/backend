using ClosedXML.Excel;

namespace TradeFlow.Backend.Reports.Generators
{
    public static class ExcelReportGenerator
    {
        public static byte[] GenerateExcel(string reportName, List<Dictionary<string, object>> rows)
        {
            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add(reportName);

            if (!rows.Any())
                return Array.Empty<byte>();

            var headers = rows.First().Keys.ToList();

            for (int i = 0; i < headers.Count; i++)
            {
                ws.Cell(1, i + 1).Value = headers[i];
                ws.Cell(1, i + 1).Style.Font.Bold = true;
            }

            for (int r = 0; r < rows.Count; r++)
            {
                for (int c = 0; c < headers.Count; c++)
                    ws.Cell(r + 2, c + 1).Value = rows[r][headers[c]]?.ToString();
            }

            ws.Columns().AdjustToContents();

            using var ms = new MemoryStream();
            wb.SaveAs(ms);
            return ms.ToArray();
        }
    }
}
