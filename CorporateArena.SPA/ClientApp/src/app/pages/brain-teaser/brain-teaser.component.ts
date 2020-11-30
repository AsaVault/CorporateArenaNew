import { QuestionService } from './../../services/question.service';
import { Component, OnInit } from '@angular/core';
import { Answer, BrainTeaser, Question } from 'src/app/models';
import { BrainTeaserAnswer } from 'src/app/models/BrainTeaserAnswer';
import { BrainTeaserService } from '../../services/brain-teaser.service';

@Component({
  selector: 'app-brain-teaser',
  templateUrl: './brain-teaser.component.html',
  styleUrls: ['./brain-teaser.component.scss'],
})
export class BrainTeaserComponent implements OnInit {
  brainTeasers: Question[];
  selectedBrainTeaser: number;
  page: number;
  pageSize: number;
  name = '';
  body = '';
  brainTeaserId;
  view = 'answer';
  username = 'admin';
  selectedEntry: boolean;

  constructor(private service: QuestionService) { }

  ngOnInit(): void {
    this.page = 1;
    this.pageSize = 10;
    this.service.getAll(1, 10).subscribe((data) => {
      this.brainTeasers = data;
      // console.log(`Brain teasers are as follows: ${JSON.stringify(this.brainTeasers)}`);
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

  submitquestionAnswer(id: number): void {

    // console.log(`Response was ${this.selectedEntry}`);

    if (this.selectedEntry === undefined)
    {
      // console.log(`Please click an option`);
      console.log('Please click an option!', 'Alert!');
      return;
    }

    const answer: Answer = {
      questionId : id,
      username : this.username,
      isCorrect: this.selectedEntry
    };

    // console.log(`sending to server: ${JSON.stringify(answer)}`);

    this.service.postAnswer(id, answer).subscribe((data) => {
      if(data.toString() === 'You have answered the question already !!!')
      {
        console.log(data.toString(), 'Alert!');
        return;
      }
      if(this.selectedEntry)
      {
        console.log('Correct!', 'Result!');
      }
      else
      {
        console.log('Incorrect', 'Result!');
      }
      // console.log(`response from server: ${data}`);
      // this.router.navigate(['/brain_teasers']);
      // window.location.reload();
    });
  }

  onSelectionChange(entry): void {
    // console.log(`radio button was clicked ${entry}`);
    this.selectedEntry = entry;
  }

  getUrl(slug: string): string {
    return `/brain-teaser/${slug}`;
  }

  getWithAnswerUrl(slug: string): string {
    return `/brain-teaser-admin/${slug}`;
  }
}
