
import { NgModule} from "@angular/core";
import { PageHeaderComponent } from "./page-header.component";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";

@NgModule({
    imports:[CommonModule, 
        RouterModule,  
        FormsModule],
    declarations: [PageHeaderComponent],
    exports: [PageHeaderComponent]
})
export class PageHeaderModule{}