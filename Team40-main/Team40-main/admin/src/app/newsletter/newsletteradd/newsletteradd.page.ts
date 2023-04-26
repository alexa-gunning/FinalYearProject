import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { TouchSequence } from 'selenium-webdriver';
import { Hosts } from 'src/models/hosts';
import { NewsletterService } from 'src/services/newsletter.service';
import { ReactiveFormsModule } from '@angular/forms';
import {FormBuilder, Validators } from "@angular/forms";
import { Router } from '@angular/router';
import { ToastController } from '@ionic/angular';
import { HttpErrorResponse } from '@angular/common/http';
// import { DocumentViewer, DocumentViewerOptions } from '@awesome-cordova-plugins/document-viewer/ngx';


@Component({
  selector: 'app-newsletteradd',
  templateUrl: './newsletteradd.page.html',
  styleUrls: ['./newsletteradd.page.scss'],
})
export class NewsletteraddPage {
  NewsletterForm : FormGroup;
  constructor(private service: NewsletterService, private formBuilder: FormBuilder, private router: Router, private toast: ToastController) {
    this.NewsletterForm = this.formBuilder.group({
      subjectline: ['',Validators.required],
      messagebody:['',Validators.required],
      attachmentraw:['',null]
     });
  }

  ngOnInit() {
  }

  AddBtn () {}

  HomeBtn () {}

  SendNewsLetter () {

    console.log("SendNewsletter Start") 
    

    if (this.NewsletterForm.valid == true){
      this.service.AddNewsletter(this.NewsletterForm.value).subscribe(() =>{
        this.router.navigate(['./newsletteradd']);
          this.presentToast();
        }
       , (response: HttpErrorResponse) => {
      this.presentToast();
       }
       )}
  
    // else{
    //   return;
    // }


  }
  
async presentToast() {
  const toast = await this.toast.create({
    message: 'Newsletter has been sent.',
    duration: 2000
  });
  toast.present();
}
async presentErrorToast() {
  const toast = await this.toast.create({
    message: 'Could not send newsletter.',
    duration: 2000
  });
  toast.present();
}

loadImageFromDevice(event) {

  const file = event.target.files[0];

  const reader = new FileReader();

  reader.readAsArrayBuffer(file);

  reader.onload = () => {

    // get the blob of the image:
    let blob: Blob = new Blob([new Uint8Array((reader.result as ArrayBuffer))]);

    // create blobURL, such that we could use it in an image element:
    let blobURL: string = URL.createObjectURL(blob);
    console.log("blobURL:" + blobURL);


  };

  reader.onerror = (error) => {

    //handle errors

  };


};






}
