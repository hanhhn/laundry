﻿using Cf.Libs.Core.Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Cf.Libs.DataAccess.Entities.Common
{
    public class Province : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Prefix { get; set; }
        public int SortOrder { get; set; }
        public bool IsPublished { get; set; }
        public virtual ICollection<District> Districts { get; set; }
    }
}