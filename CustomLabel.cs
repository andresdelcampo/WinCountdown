using System.Drawing.Drawing2D;

public class CustomLabel : Label
{
    public CustomLabel()
    {
        OutlineForeColor = Color.Black;
        OutlineWidth = 2;
    }
    public Color OutlineForeColor { get; set; }
    public float OutlineWidth { get; set; }

    protected override void OnPaint(PaintEventArgs e)
    {
        using (GraphicsPath gp = new GraphicsPath())
        using (StringFormat sf = new StringFormat())
        {
            gp.AddString(Text, Font.FontFamily, (int)Font.Style,
                Font.Size, ClientRectangle, sf);

            e.Graphics.ScaleTransform(1.3f, 1.35f);
            e.Graphics.SmoothingMode = SmoothingMode.None; // No anti-aliasing to avoid blending
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            // Draw the black outline by widening the path
            using (GraphicsPath outlinePath = (GraphicsPath)gp.Clone())
            {
                using (Pen outlinePen = new Pen(OutlineForeColor, OutlineWidth * 2))
                {
                    outlinePath.Widen(outlinePen);
                }
                using (SolidBrush outlineBrush = new SolidBrush(OutlineForeColor))
                {
                    e.Graphics.FillPath(outlineBrush, outlinePath);
                }
            }

            // Fill the text in the foreground color
            using (SolidBrush foreBrush = new SolidBrush(ForeColor))
            {
                e.Graphics.FillPath(foreBrush, gp);
            }
        }
    }
}
