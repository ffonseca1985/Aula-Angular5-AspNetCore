
import {Component, Input } from "@angular/core";

@Component({
    selector: "app-page-header",
    templateUrl: "./page-header.component.html"
})
export class PageHeaderComponent {

    @Input() heading : string;
    @Input() icon : string;
} 