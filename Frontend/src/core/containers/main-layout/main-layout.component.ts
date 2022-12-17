import { Component, OnInit } from '@angular/core';
import { UserDto } from 'src/core/model/user/user.dto';
import { AuthService } from 'src/core/services/auth.service';

@Component({
  selector: 'app-main-layout',
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.scss']
})
export class MainLayoutComponent implements OnInit {

  username: string;
  user: UserDto;
  refreshTimeout: any;

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.authService.userValue.subscribe(e => this.username = e.userName);
  }
  
  handleLogout(): void {
    this.authService.logout();
  }
}
