using Lab10.White;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    public interface IWhiteSerializer
    {
        void Serialize(Lab9.White.White obj);
    }
    public interface IGreenSerializer
    {
        void Serialize<T>(T obj) where T : Lab9.Green.Green;
    }
    public interface IBlueSerializer<T> where T : Lab9.Blue.Blue
    {
        void Serialize(T obj);
    }
    public interface IPurpleSerializer<T> where T : Lab9.Purple.Purple
    {
        void Serialize(T obj);
    }
}
