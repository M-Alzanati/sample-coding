import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import {
  AbstractControl,
  FormArray,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { MessageService } from 'primeng/api';
import { first } from 'rxjs';
import { AuthService } from 'src/core/services/auth.service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.scss'],
})
export class LoginFormComponent implements OnInit {
  form: FormGroup;
  @Input() isLoading: boolean;
  @Output() onSubmit: EventEmitter<any> = new EventEmitter();
  error = '';

  constructor(private fb: FormBuilder, private authService: AuthService, private msgServ: MessageService) {}

  get username() {
    return this.form?.get('username');
  }

  get password() {
    return this.form?.get('password');
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required]],
    });
  }

  handleSubmit(): void {
    const { value, valid } = this.form;
    if (!valid) {
      this.markFieldsAsDirty(this.form);
      return;
    }

    this.authService.login({userName: value.username, password: value.password})
    .pipe(first())
    .subscribe(
      data => {
        this.onSubmit.emit({ ...value, username: value.username?.trim() });
      },
      error => {
        this.msgServ.add({
          severity: "error",
          summary: "Error ",
          detail: "custome error message..."
        });
        
        this.error = error;
      }
    );
  }

  markFieldsAsDirty(form: AbstractControl): void {
    form.markAsDirty({ onlySelf: true });
    if (form instanceof FormArray || form instanceof FormGroup) {
      Object.values(form.controls).forEach(this.markFieldsAsDirty);
    }
  }
}
