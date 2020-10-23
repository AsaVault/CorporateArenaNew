import { Component, OnInit } from '@angular/core';
import { BrainTeaser, CommentRequest } from 'src/app/models';
import { BrainTeaserAnswer } from 'src/app/models/BrainTeaserAnswer';
import { BrainTeaserService } from '../../services/brain-teaser.service';

@Component({
  selector: 'app-brain-teaser',
  templateUrl: './brain-teaser.component.html',
  styleUrls: ['./brain-teaser.component.scss'],
})
export class BrainTeaserComponent implements OnInit {
  brainTeasers: BrainTeaser[];
  selectedBrainTeaser: number;
  name = '';
  body = '';
  brainTeaserId;
  view = '';
  isSubmitted: boolean;

  constructor(private service: BrainTeaserService) { }

  ngOnInit(): void {
    this.service.getAll().subscribe((brainTeasers) => {
      this.brainTeasers = brainTeasers;
      if (this.brainTeasers.length > 0) {
        this.selectedBrainTeaser = this.brainTeasers[0].id;
      }
    });
  }

  toggleView(view: string): void {
    this.view = view;
  }

  toggleSelected(selected: number = null): void {
    if (selected) {
      if (this.isSelected(selected)) {
        return;
      }

      this.selectedBrainTeaser = selected;
      console.log(selected);
      return;
    }
    this.selectedBrainTeaser = null;
  }

  isSelected(id: number): boolean {
    return id === this.selectedBrainTeaser;
  }

  submitAnswer(id: number): void {
    if (this.body.length === 0 || this.name.length === 0) {
      return;
    }

    const answer: BrainTeaserAnswer = {
      id: 0,
      dateCreated: new Date(),
      userCreated: 1,
      userName: this.name,
      answer: this.body,
      isApproved: false,
      brainTeaserID: id,
    };

    this.service.postAnswer(id, answer).subscribe((newComment) => {
      // this.brainTeasers[id].brainTeaserAnswers = [
      //   newComment,
      //   ...this.brainTeasers[id].brainTeaserAnswers,
      // ];
      this.body = '';
      this.name = '';
      this.isSubmitted = true;
    });
  }

  getUrl(slug: string): string {
    return `/brain-teaser/${slug}`;
  }

  getWithAnswerUrl(slug: string): string {
    return `/brain-teaser-admin/${slug}`;
  }
}
