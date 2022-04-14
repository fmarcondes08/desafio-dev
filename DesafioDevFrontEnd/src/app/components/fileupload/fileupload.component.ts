import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { UploadService } from '../services/upload.service';

@Component({
  selector: 'app-fileupload',
  templateUrl: './fileupload.component.html',
  styleUrls: ['./fileupload.component.css']
})
export class FileuploadComponent implements OnInit {
  file?: File;
  returnMessage = '';
  @Output() complete = new EventEmitter();

  fileInfos?: Observable<any>;
  constructor(public uploadservice: UploadService) { }

  ngOnInit(): void {
  }

  selectFile(event: any): void {
    console.log(event)
    this.file = event.target.files[0];
    this.validateUploadFile();
  }

  private validateUploadFile(): void {
    if (this.file?.type === 'text/plain') {
      this.upload();

    } else {
      this.returnMessage = "Only accept .txt files"
    }
  }

  getdata(value: any): void {
      if (value.body.length>0) {
        this.complete.emit(value.body);
      } else {
        this.returnMessage = "There is no data already loaded. Try to insert a file."
      }
  }

  private async upload(): Promise<void> {
      const fileUpload: any =  this.file;
      await this.uploadservice.uploadFile(fileUpload).toPromise().then(async (value) => {
        this.getdata(value);
      },
        () => {this.returnMessage = 'An error has occurred. Please, try again later! ';});
    }
}
