using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaRottaO.CSharp.CarSimDashboard
{
    internal interface IUsb
    {
        Boolean isBoardConnected();

        (Boolean success, String failureReason) connectToBoard();

        (Boolean success, String failureReason) sendDataToBoard(String data);

        (Boolean succes, String failureReason) disconnectBoard();
    }
}