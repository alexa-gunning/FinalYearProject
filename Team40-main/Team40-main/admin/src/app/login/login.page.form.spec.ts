/* eslint-disable eol-last */
/* eslint-disable @typescript-eslint/semi */
/* eslint-disable @typescript-eslint/no-shadow */
/* eslint-disable @typescript-eslint/no-unused-expressions */
/* eslint-disable no-trailing-spaces */
/* eslint-disable new-parens */
/* eslint-disable @typescript-eslint/quotes */
import { FormBuilder, FormGroup } from "@angular/forms";
import { LoginPageForm } from "./login.page.form";

describe('LoginPageForm',()=>{
    
    let form: FormGroup;
    let loginPageForm: LoginPageForm;

    beforeEach(()=>{
        const loginPageForm = new LoginPageForm(new FormBuilder);
         const form = loginPageForm.createForm();
    })

    it("create an empty login form",()=>{
        expect(form).not.toBeNull();
        expect(form.get('userName')).not.toBeNull
        expect(form.get('userName').value).toEqual("");
        expect(form.get('userName').value).toBeFalsy();
        expect(form.get('password')).not.toBeNull
        expect(form.get('password').value).toEqual("");
        expect(form.get('password').value).toBeFalsy();
    })

    it("should have a valid form",()=>{
        form.get('userName').setValue('tokollo');
        form.get('password').setValue('anyPassword');
        expect(form.valid).toBeTrue;
    })
})