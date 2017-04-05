using System;
using System.Collections.Generic;

namespace ITextSharpPDF.DTO
{
    public class TreePermissionDto
    {
        public TreePermissionDto()
        {
            Feature = new FeatureInfo();
            Actions = new List<ActionInfo>();
        }

        public FeatureInfo Feature { get; set; }

        public List<ActionInfo> Actions { get; set; } 
    }

    public class FeatureInfo
    {
        public Guid FeatureId { get; set; }

        public string Name { get; set; }

        public bool IsUsed { get; set; }
    }

    public class ActionInfo
    {
        public string ActionId { get; set; }

        public bool IsUsed { get; set; }
    }
}
