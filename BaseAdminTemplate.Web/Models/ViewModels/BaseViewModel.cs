﻿using System;

namespace BaseAdminTemplate.Web.Models.ViewModels
{
    public class BaseViewModel
    {
        public Guid Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsActive { get; set; }
    }
}