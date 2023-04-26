/* eslint-disable eol-last */
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

export class ForgotpasswordPageForm{

    private formBuilder: FormBuilder;

    constructor(formBuilder: FormBuilder){
        this.formBuilder= formBuilder;
    }

    createForm(): FormGroup{
        return this.formBuilder.group({
            userName:['',[Validators.required]],
            // password:['',[Validators.required]]
        });
    }
}