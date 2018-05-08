using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using JSJ.SysFrame.DB;
using JSJ.SysFrame;
using System.Collections;

namespace JSJ.CJZC.Business
{
    /// <summary>
    /// �û�ҵ������
    /// </summary>
    public class ZX_InfoReadBU: IDisposable
    {
        #region ���Զ���
        private const string TabName = "ZX_InfoRead";
        private CommTable tabCommand = null;
        #endregion

        #region ���캯��
        public ZX_InfoReadBU(SinConnect tabconn)
        {
            tabCommand = new CommTable();
            tabCommand.TabName = TabName;
            tabCommand.TableConnect = tabconn;
        }

        public ZX_InfoReadBU()
            : this(Util.GetDefaultConnect())
        {

        }
        #endregion

        #region ҵ�񷽷�
        //ɾ��һ����Ϣ��ɾ����������Ϣ�������û�
        public void DelDataByID(string id)
        {
            this.tabCommand.DeleteData(new SearchField("infoid", id, SearchFieldType.��ֵ��));
        }
        #endregion

        #region ˽�з���

        #endregion

        #region IDisposable ��Ա
        public void Dispose()
        {
            this.Close();
        }

        public void Close()
        {
            if (this.tabCommand != null)
            {
                this.tabCommand.Close();
            }
        }
        #endregion
    }
}
