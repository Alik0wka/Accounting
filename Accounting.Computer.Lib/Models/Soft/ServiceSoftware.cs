using LiteDB;               
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Computer.Lib.Models.Soft
{
    public delegate void SendNotification(SoftWare sw);
    public struct ServiceSoftware
    {
        PrintMessage printMessage;
        ShowError showError;
        SendNotification sendNotification;

        public void RegisterNotification(SendNotification sendNotification)
        {
            this.sendNotification = sendNotification;
        }

        public void RegisterMessage(PrintMessage printMessage)
        {
            this.printMessage = printMessage;
        }

        public void RegisterError(ShowError showError)
        {
            this.showError = showError;
        }

        public string DBName { get; set; }

        public void AddSoftware(SoftWare softWare)
        {
            try
            {
                if (string.IsNullOrEmpty(DBName))
                    throw new Exception("Введи строку ублюдок");

                using (LiteDatabase db = new LiteDatabase(DBName))
                {
                    var softWares = db.GetCollection<SoftWare>("SoftWare");
                    softWares.Insert(softWare);
                }
                if (printMessage != null)
                    printMessage.Invoke("Всё окей рукожоп");

                if (sendNotification != null)
                    sendNotification.Invoke(softWare);
            }
            catch (Exception ex)
            {
                if (showError != null)
                {
                    showError.Invoke(ex);
                }
            }
        }

        public void EditSoftware(Software software)
        {
            try
            {
                if (string.IsNullOrEmpty(DBName))   
                    throw new Exception("Введи строку ублюдок");

                using (LiteDatabase db = new LiteDatabase(DBName))
                {
                    var equipments = db.GetCollection<Software>("Software");
                    equipments.Update(software);
                }
                if (printMessage != null)
                    printMessage.Invoke("Всё окей рукожоп");
            }
            catch (Exception ex)
            {
                if (showError != null)
                {
                    showError.Invoke(ex);
                }
            }
        }

        public void DelSoftware(int software)
        {
            try
            {
                if (string.IsNullOrEmpty(DBName))
                    throw new Exception("Введи строку ублюдок");

                using (LiteDatabase db = new LiteDatabase(DBName))
                {
                    var equipments = db.GetCollection<Software>("Software");
                    equipments.Delete(" ");
                }
                if (printMessage != null)
                    printMessage.Invoke("Запись удалена");
            }
            catch (Exception ex)
            {
                if (showError != null)
                {
                    showError.Invoke(ex);
                }
            }
        }

    }
}