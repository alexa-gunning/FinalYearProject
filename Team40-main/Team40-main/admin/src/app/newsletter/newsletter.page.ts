import { Component, OnInit } from '@angular/core';
import { FormControl,FormGroup } from '@angular/forms';
import { Validators,FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { Newsletter } from 'src/models/newsletter';
import { NewsletterService } from 'src/services/newsletter.service';
import { ReactiveFormsModule } from '@angular/forms';
import { NewsletteraddPage } from './newsletteradd/newsletteradd.page';


@Component({
  selector: 'app-newsletter',
  templateUrl: './newsletter.page.html',
  styleUrls: ['./newsletter.page.scss'],
})

export class NewsletterPage{
  SendMailFormGroup: FormGroup;
  constructor(private NewsletterService: NewsletterService, private formBuilder: FormBuilder,private router:Router)
  {
    this.SendMailFormGroup = this.formBuilder.group({
      deliveryCompanyName:['',Validators.required],
      subject:['',Validators.required],
      messagebody:['',Validators.required]
    });
  }

  ngOnInit() {
  }

  AddBtn() 
  {
    this.router.navigate(['newsletteradd']);
  }

    
  HomeBtn()
  {
    this.router.navigate(['./newsletter']);
  }


}