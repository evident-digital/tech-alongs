using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    /// <summary>
    /// Abstract class representing a single ORM entity in EntityFramework.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        /// <remarks>
        /// EntityFramework Constructor
        /// </remarks>
        protected Entity()
        {
        }

        /// <summary>
        /// Gets or sets the primary key for this entity.
        /// </summary>
        public Guid Id { get; set; }
    }
}