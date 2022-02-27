﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp15.DTO;
using WpfApp15.Model;
using WpfApp15.Pages;
using WpfApp15.Tools;

namespace WpfApp15.ViewModels
{
    public class EditCuratorVM : BaseVM
    {
        public Curator EditCurator { get; }
        public CommandVM SaveCurator { get; set; }
        public Group CuratorGroup
        {
            get => curatorGroup;
            set
            {
                curatorGroup = value;
                Signal();
            }
        }

        public List<Group> Groups { get; set; }

        private CurrentPageControl currentPageControl;
        private Group curatorGroup;

        public EditCuratorVM(CurrentPageControl currentPageControl)
        {
            this.currentPageControl = currentPageControl;
            EditCurator = new Curator();
            Init();
        }

        public EditCuratorVM(Curator editCurator, CurrentPageControl currentPageControl)
        {
            EditCurator = editCurator;
            this.currentPageControl = currentPageControl;
            Init();
//            CuratorGroup = Groups.FirstOrDefault(s => s.ID == editCurator.GroupId);
        }

        private void Init()
        {
            Groups = SqlModel.GetInstance().SelectGroupsRange(0, 100);
            SaveCurator = new CommandVM(() => {
                //if (CuratorGroup == null)
                //{
                //    System.Windows.MessageBox.Show("Нужно выбрать группу для продолжения");
                //    return;
                //}
//                EditCurator.GroupId = CuratorGroup.ID;
                var model = SqlModel.GetInstance();
                if (EditCurator.ID == 0)
                    model.Insert(EditCurator);
                else
                    model.Update(EditCurator);
                currentPageControl.SetPage(new ViewCuratorsPage(CuratorGroup));
            });
        }

    }
}
