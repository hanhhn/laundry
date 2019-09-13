import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Post } from "src/app/cores/models/post.model";
import { SettingService } from "src/app/cores/services/setting.service";
import { Reason } from "src/app/cores/models/setting.model";
import { PostService } from "src/app/cores/services/post.service";
import { forkJoin } from "rxjs";

@Component({
  selector: "app-learn-more",
  templateUrl: "./learn-more.component.html",
  styleUrls: ["./learn-more.component.scss"]
})
export class LearnMoreComponent implements OnInit {
  submitted: boolean;
  formControls: FormGroup;

  dataSource: Post[];

  postsId: string[];

  get controls() {
    return this.formControls.controls;
  }

  constructor(
    private formBuilder: FormBuilder,
    private settingsService: SettingService,
    private postService: PostService
  ) {
    this.formControls = this.formBuilder.group({
      posts: [null, Validators.required]
    });
  }

  ngOnInit() {
    this.getSettings();
  }

  getSettings() {
    forkJoin([
      this.postService.getAll(0, 100),
      this.settingsService.getHomePost()
    ]).subscribe(([source, posts]) => {
      this.dataSource = source ? source.dataSource : [];

      if (posts) {
        const items = this.dataSource.map(x => posts.includes(x.id));
        this.controls.posts.setValue(items);
      }
    });
  }

  onSaveClicked(event) {
    event.preventDefault();
    this.submitted = true;
    this.formControls.markAllAsTouched();

    if (this.formControls.valid) {
      const ids = this.controls.posts.value;
      const item = ids.map((x: Post) => x.id);

      this.settingsService.saveHomePost(item).subscribe(data => {
        if (data) {
          alert("Lưu dữ liệu thành công!");
        } else {
          alert("Xảy ra lỗi");
        }
      });
    }
  }
}
