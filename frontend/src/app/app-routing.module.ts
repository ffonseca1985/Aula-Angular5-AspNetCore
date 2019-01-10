
import { Routes, RouterModule } from "@angular/router";
import { NgModule } from "@angular/core";
import { OauthGuard } from "./shared/guards/oauth.guard";

const routes : Routes = [
    { path: "", loadChildren: "./modules/home.module#HomeModule", canActivate: [OauthGuard]},
    { path: "login", loadChildren: "./login/login.module#LoginModule"},
    { path: "not-found", loadChildren: "./not-found/not-found.module#NotFoundModule"},
    { path: "**", redirectTo: "not-found"}
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}