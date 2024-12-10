﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ZQH.Abp.Notifications;

public class NotificationMarkReadStateInput
{
    [Required]
    [DisplayName("Notifications:Id")]
    public long[] IdList { get; set; }

    [DisplayName("Notifications:State")]
    public NotificationReadState State { get; set; }
}
