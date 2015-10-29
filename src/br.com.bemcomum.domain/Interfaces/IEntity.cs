using System;

namespace br.com.bemcomum.domain.Interfaces
{
    public interface IEntity<T> where T : struct
    {
        T Id { get; set; }

        bool IsActive { get; set; }

        DateTime Save { get; set; }

        DateTime Update { get; set; }
    }
}
