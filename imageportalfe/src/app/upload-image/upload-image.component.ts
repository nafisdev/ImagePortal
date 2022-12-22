import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { ImageProcessService } from 'src/service/image-process.service';

@Component({
  selector: 'app-upload-image',
  templateUrl: './upload-image.component.html',
  styleUrls: ['./upload-image.component.scss']
})
export class UploadImageComponent implements OnInit {
  imageGroup: FormGroup=this.form.group({
    imageName: new FormControl('', Validators.required),
    imageFile: new FormControl('', [Validators.required])
  });
  file: any;

  constructor(public form: FormBuilder,private imageService: ImageProcessService, private router: Router) { }
  baseUrl: string = environment.baseUrl;
  // , requiredFileType('jpg')
  ngOnInit(): void {

    this.buildForm();
    
  }
  public buildForm() {

    this.imageGroup.valueChanges.subscribe((data) => {
      //validation
    });
  }

  handleFileInput(event: any)
  {
    const reader = new FileReader();

    const imgData = new FormData();
    imgData.append("ImageFile" , this.file);
    imgData.append("ImageName" , this.imageGroup.value.imageName);
    this.imageService.uploadImage(imgData).subscribe(x => 
      {
        window.location.href = `http://localhost:4200/image`;
      });
    // // const file = event.target.files[0];
    // const imgData = new FormData();
    // imgData.append("ImageFile" , file);
    // imgData.append("ImageName" , );
    // this.imageService.uploadImage(imgData).subscribe(x => 
    //   {
    //     this.router.navigateByUrl(`${this.baseUrl}/Image`);
    //   });
    
  }

  OnSelect(event: any)
  {
    const reader = new FileReader();
    this.file = event.target.files[0];
    
  }
  

}
function requiredFileType(arg0: string): import("@angular/forms").ValidatorFn {
  throw new Error('Function not implemented.');
}

