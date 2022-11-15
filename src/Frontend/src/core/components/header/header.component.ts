import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { filter } from 'rxjs';
import { UserDto } from 'src/core/model/user/user.dto';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  userMenu: MenuItem[];
  helpCenterMenu: MenuItem[];
  showAccountDropdown: boolean;

  @Input() username: string;
  @Output() onLogout = new EventEmitter();
  @Output() onChangeAccount = new EventEmitter();

  constructor(private router: Router) {}

  ngOnInit(): void {
    this.userMenu = [
      {
        label: 'Profile',
        routerLink: '/profile',
      },
      {
        separator: true,
      },
      {
        label: 'Sign Out',
        command: () => this.onLogout.emit(),
      },
    ];

    this.helpCenterMenu = [
      {
        label: 'Support',
        url: 'mailto:support@vynecorp.com?subject=Refyne Support',
      }
    ];
  }
}
