using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    /// <summary>
    /// 备忘录模式
    /// </summary>
    class GameRole
    {
        public int vit { get; set; }
        public int atk { get; set; }
        public int def { get; set; }

        /// <summary>
        /// 状态显示
        /// </summary>
        public void StateDisplay()
        {
            Console.WriteLine("角色状态");
            Console.WriteLine("体力：{0}", this.vit);
            Console.WriteLine("攻击：{0}", this.atk);
            Console.WriteLine("防御：{0}", this.def);
        }
        /// <summary>
        /// 初始状态
        /// </summary>
        public void GetInitState()
        {
            this.vit = 100;
            this.atk = 100;
            this.def = 100;
        }
        /// <summary>
        /// 战斗
        /// </summary>
        public void Fight()
        {
            this.vit = 0;
            this.atk = 0;
            this.def = 0;
        }

        public RoleStateMemnto SaveState()
        {
            return (new RoleStateMemnto(vit, atk, def));
        }

        public void RecoveryState(RoleStateMemnto memnto)
        {
            this.vit = memnto.vit;
            this.atk = memnto.atk;
            this.def = memnto.def;
        }
    }

    /// <summary>
    /// 状态存储箱
    /// </summary>
    class RoleStateMemnto
    {
        public int vit { get; set; }
        public int atk { get; set; }
        public int def { get; set; }

        public RoleStateMemnto(int vit, int atk, int def)
        {
            this.vit = vit;
            this.atk = atk;
            this.def = def;
        }
    }

    class RoleStateCaretaker
    {
        public RoleStateMemnto memnto { get; set; }

    }


}
