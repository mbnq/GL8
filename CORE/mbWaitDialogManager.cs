using GL8.CORE;
using System.Windows.Forms;

public class mbWaitDialogManager
{
    private mbWaitDialog _waitDialog;

    public void Start(Form parentForm)
    {
        if (_waitDialog != null && !_waitDialog.IsDisposed)
            return;

        _waitDialog = new mbWaitDialog();
        _waitDialog.Cursor = Cursors.WaitCursor;

        if (parentForm != null)
        {
            _waitDialog.Owner = parentForm;
            _waitDialog.StartPosition = FormStartPosition.CenterParent;
        }
        else
        {
            _waitDialog.StartPosition = FormStartPosition.CenterScreen;
        }

        _waitDialog.Show();
    }

    public void Stop()
    {
        if (_waitDialog != null && !_waitDialog.IsDisposed)
        {
            _waitDialog.Cursor = Cursors.Default;
            _waitDialog.Close();
            _waitDialog = null;
        }
    }
}
