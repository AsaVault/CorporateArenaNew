import { CommentRequestTrafficUpdate } from './../../models/CommentRequestTrafficUpdate';
import { Component, OnInit } from '@angular/core';
import { TrafficUpdate, Comment, CommentRequest } from 'src/app/models';
import { TrafficUpdateService } from 'src/app/services/traffic-update.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-traffic-update-article',
  templateUrl: './traffic-update-article.component.html',
  styleUrls: ['./traffic-update-article.component.scss'],
})
export class TrafficUpdateArticleComponent implements OnInit {
  trafficUpdate: TrafficUpdate;
  name = '';
  body = '';
  articleId: number;
  constructor(
    private service: TrafficUpdateService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.service
      .getBySlug(this.route.snapshot.paramMap.get('id'))
      .subscribe((trafficUpdate) => {
        this.trafficUpdate = trafficUpdate;
        this.articleId = trafficUpdate.id;
      });
  }

  submitComment(): void {
    if (this.body.length === 0 || this.name.length === 0) {
      return;
    }

    const comment: CommentRequestTrafficUpdate = {
      id: 0,
      title: this.name,
      comment: this.body,
      trafficUpdateId: this.articleId,
      dateCreated: new Date()
    };

    this.service
      .postComment(comment)
      .subscribe((newComment) => {
        this.trafficUpdate.trafficUpdateComments = [
          newComment,
          ...this.trafficUpdate.trafficUpdateComments,
        ];
        this.body = '';
        this.name = '';
      });
  }
}
