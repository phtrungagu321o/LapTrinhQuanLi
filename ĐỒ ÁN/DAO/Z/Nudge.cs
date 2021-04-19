using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ĐỒ_ÁN.DAO.Z
{
    class Nudge
    {
        private Form tmpFrm;
        public Nudge(Form theForm)
        {
            this.tmpFrm = theForm;
        }
        public void NudgeMe()
        {
            int xCoord = this.tmpFrm.Left;
            int yCoord = this.tmpFrm.Top;
            int rnd = 0;

            Random RandomClass = new Random();

            for (int i = 0; i <= 100; i++)
            {
                rnd = RandomClass.Next(xCoord + 1, xCoord + 15);
                this.tmpFrm.Left = rnd;
                rnd = RandomClass.Next(yCoord + 1, yCoord + 15);
                this.tmpFrm.Top = rnd;
            }

            this.tmpFrm.Left = xCoord;
            this.tmpFrm.Top = yCoord;
        }
    }
}
