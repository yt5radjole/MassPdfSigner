using System;
using System.Windows.Forms;
using System.Drawing;

namespace MassPdfSigner
{
    public partial class MainForm : Form
    {
        // relativne koordinate (0..1) za ručnu poziciju potpisa kod pojedinačnog potpisivanja
        private float? _manualXRelSingle;
        private float? _manualYRelSingle;

        public MainForm()
        {
            InitializeComponent();

            // početne vrednosti
            cmbPositionSingle.SelectedIndex = 3; // Dole desno
            cmbPositionBatch.SelectedIndex = 3;  // Dole desno

            // podrazumevano: poslednja strana (MUP stil)
            rdoSingleLast.Checked = true;
            rdoBatchLast.Checked = true;
        }

        // ===========================
        //  POJEDINAČNO POTPISIVANJE
        // ===========================

        private void btnBrowseSingle_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "PDF fajlovi (*.pdf)|*.pdf";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtSingleFile.Text = ofd.FileName;
                }
            }
        }

        private void btnSignSingle_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSingleFile.Text))
                {
                    MessageBox.Show("Izaberi PDF fajl.", "Upozorenje",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF fajlovi (*.pdf)|*.pdf";
                    sfd.FileName = System.IO.Path.GetFileNameWithoutExtension(txtSingleFile.Text) + "_signed.pdf";

                    if (sfd.ShowDialog() != DialogResult.OK)
                        return;

                    SignatureCorner corner = GetCornerFromCombo(cmbPositionSingle);

                    // true = poslednja strana, false = prva
                    bool signOnLastPage = rdoSingleLast.Checked;

                    float? manualX = null;
                    float? manualY = null;

                    if (corner == SignatureCorner.Manual &&
                        _manualXRelSingle.HasValue &&
                        _manualYRelSingle.HasValue)
                    {
                        manualX = _manualXRelSingle.Value;
                        manualY = _manualYRelSingle.Value;
                    }

                    PdfSignerService.SignSinglePdf(
                        txtSingleFile.Text,
                        sfd.FileName,
                        corner,
                        chkAutoFreeSingle.Checked,
                        manualX,
                        manualY,
                        signOnLastPage);
                }

                MessageBox.Show("Dokument je uspešno potpisan.", "OK",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPreviewSingle_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSingleFile.Text))
                {
                    MessageBox.Show("Izaberi PDF fajl.", "Upozorenje",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SignatureCorner corner = GetCornerFromCombo(cmbPositionSingle);
                bool signOnLastPage = rdoSingleLast.Checked;

                float? manualX = null;
                float? manualY = null;

                if (corner == SignatureCorner.Manual &&
                    _manualXRelSingle.HasValue &&
                    _manualYRelSingle.HasValue)
                {
                    manualX = _manualXRelSingle.Value;
                    manualY = _manualYRelSingle.Value;
                }

                PdfSignerService.PreviewSignature(
                    txtSingleFile.Text,
                    corner,
                    chkAutoFreeSingle.Checked,
                    manualX,
                    manualY,
                    signOnLastPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // “A4” panel za ručnu poziciju
        private void pnlManualPosSingle_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.WhiteSmoke);

            // okvir stranice
            int margin = 10;
            Rectangle rect = new Rectangle(
                margin,
                margin,
                pnlManualPosSingle.Width - 2 * margin,
                pnlManualPosSingle.Height - 2 * margin);

            e.Graphics.DrawRectangle(Pens.Gray, rect);

            // ako postoji ručna pozicija, nacrtaj malu tačku
            if (_manualXRelSingle.HasValue && _manualYRelSingle.HasValue)
            {
                float relX = _manualXRelSingle.Value;
                float relY = _manualYRelSingle.Value; // 0..1 (0 dno, 1 vrh – u našem kodu smo mapirali obrnuto)

                // isti mapping kao u MouseClick: X: 0..1 → širina, Y: 0..1 → visina
                float px = rect.Left + relX * rect.Width;
                float py = rect.Bottom - relY * rect.Height;

                float r = 4f;
                e.Graphics.FillEllipse(Brushes.Red, px - r, py - r, 2 * r, 2 * r);
            }
        }

        private void pnlManualPosSingle_MouseClick(object sender, MouseEventArgs e)
        {
            // relativna pozicija u panelu 0..1,0..1
            float relX = (float)e.X / (float)pnlManualPosSingle.Width;
            float relY = (float)(pnlManualPosSingle.Height - e.Y) / (float)pnlManualPosSingle.Height;

            _manualXRelSingle = relX;
            _manualYRelSingle = relY;

            pnlManualPosSingle.Invalidate();
        }

        // ===========================
        //  MASOVNO POTPISIVANJE
        // ===========================

        private void btnBrowseInputFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                    txtInputFolder.Text = fbd.SelectedPath;
            }
        }

        private void btnBrowseOutputFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                    txtOutputFolder.Text = fbd.SelectedPath;
            }
        }

        private void btnBrowseArchiveFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtArchiveFolder.Text = fbd.SelectedPath;
                    chkArchiveOriginals.Checked = true;
                }
            }
        }

        private void btnSignBatch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtInputFolder.Text))
                {
                    MessageBox.Show("Izaberi ulazni folder.", "Upozorenje",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtOutputFolder.Text))
                {
                    MessageBox.Show("Izaberi izlazni folder.", "Upozorenje",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string archiveFolder = null;
                if (chkArchiveOriginals.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtArchiveFolder.Text))
                    {
                        MessageBox.Show(
                            "Označeno je 'Arhiviraj originale', ali nije izabran arhivski folder.",
                            "Upozorenje",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    archiveFolder = txtArchiveFolder.Text;
                }

                SignatureCorner corner = GetCornerFromCombo(cmbPositionBatch);

                // true = poslednja strana, false = prva
                bool signOnLastPage = rdoBatchLast.Checked;

                PdfSignerService.SignAllInFolder(
                    txtInputFolder.Text,
                    txtOutputFolder.Text,
                    archiveFolder,
                    corner,
                    chkAutoFreeBatch.Checked,
                    null,
                    null,
                    signOnLastPage);

                MessageBox.Show("Masovno potpisivanje završeno.", "OK",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===========================
        //  POMOĆNE METODE
        // ===========================

        private SignatureCorner GetCornerFromCombo(ComboBox combo)
        {
            switch (combo.SelectedIndex)
            {
                case 0:
                    return SignatureCorner.TopLeft;
                case 1:
                    return SignatureCorner.TopRight;
                case 2:
                    return SignatureCorner.BottomLeft;
                case 3:
                    return SignatureCorner.BottomRight;
                case 4:
                    return SignatureCorner.Center;
                case 5:
                    return SignatureCorner.Manual;
                default:
                    return SignatureCorner.BottomRight;
            }
        }
    }
}
