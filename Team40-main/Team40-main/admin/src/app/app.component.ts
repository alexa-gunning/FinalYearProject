import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { BnNgIdleService } from 'bn-ng-idle';
@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
})
export class AppComponent {
  constructor(private bnIdle: BnNgIdleService, private router: Router) { // initiate it in your component constructor
    this.bnIdle.startWatching(300).subscribe((res) => {
      if(res) {
          console.log("session expired");
          localStorage.removeItem('Token')
          this.router.navigate(['./login']);
      }
    })
  }

  toggleLogin = JSON.parse(localStorage.getItem('User')!)
}
