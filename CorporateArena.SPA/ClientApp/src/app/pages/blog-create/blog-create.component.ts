import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Blog, CommentRequest } from 'src/app/models';
import { BlogService } from '../../services/blog.service';

@Component({
  selector: 'app-blog-create',
  templateUrl: './blog-create.component.html',
  styleUrls: ['./blog-create.component.scss']
})
export class BlogCreateComponent implements OnInit {
  blog: Blog;
  title = '';
  content = '';
  constructor(private service: BlogService, private route: Router) { }

  ngOnInit(): void {
  }

  submitArticle(): void {
    if (this.content.length === 0 || this.title.length === 0) {
      return;
    }
    this.blog = {
      title: this.title,
      content: this.content,
      slug: 'nothing',
      id: 0,
      comments: null,
      publishedAt: null,
      dateCreated: new Date(),
    };
    this.service
      .postArticle(this.blog)
      .subscribe((response) => {
        this.content = '';
        this.title = '';
        this.route.navigate(['/blog']);
      });
  }
}
