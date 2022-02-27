using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.DTO;
using WpfApp15.Model;

namespace WpfApp15.ViewModels
{
    public class ViewCuratorsVM : BaseVM
    {
        private Group selectedGroup;
        private List<Curator> curatorsBySelectedGroup;

        public List<Group> Groups { get; set; }
        public Group SelectedGroup
        {
            get => selectedGroup;
            set
            {
                selectedGroup = value;
                CuratorsBySelectedGroup = SqlModel.GetInstance().SelectCurators(selectedGroup);
                Signal();
            }
        }
        public List<Curator> CuratorsBySelectedGroup
        {
            get => curatorsBySelectedGroup;
            set
            {
                curatorsBySelectedGroup = value;
                Signal();
            }
        }
        public Curator SelectedCurator { get; set; }

        public ViewCuratorsVM(Group selectedGroup)
        {
            SqlModel sqlModel = SqlModel.GetInstance();
            Groups = sqlModel.SelectGroupsRange(0, 100);
            SelectedGroup = Groups.FirstOrDefault(s => s.ID == selectedGroup?.ID);
        }
    }
}
