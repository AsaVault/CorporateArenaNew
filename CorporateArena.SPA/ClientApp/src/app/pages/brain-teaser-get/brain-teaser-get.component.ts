import { BrainTeaserRequest } from './../../models/BrainTeaserRequest';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BrainTeaser } from 'src/app/models';
import { BrainTeaserAnswer } from 'src/app/models/BrainTeaserAnswer';
import { BrainTeaserService } from 'src/app/services/brain-teaser.service';

@Component({
  selector: 'app-brain-teaser-get',
  templateUrl: './brain-teaser-get.component.html',
  styleUrls: ['./brain-teaser-get.component.scss']
})
export class BrainTeaserGetComponent implements OnInit {
  brainTeaser: BrainTeaser;
  name = '';
  body = '';
  brainTeaserId;
  selectedBrainTeaser: number;
  view = 'answer';
  userId = 1;
  isApproved = false;
  isDisplayed = false;
  constructor(private service: BrainTeaserService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.service
      .getWithAnswer(this.route.snapshot.paramMap.get('id'))
      .subscribe((brainTeaser) => {
        this.brainTeaser = brainTeaser;
        console.log(this.brainTeaser);
        this.brainTeaserId = brainTeaser.id;
      });
  }

  refreshPage(): void {
    this.service
      .getWithAnswer(this.route.snapshot.paramMap.get('id'))
      .subscribe((brainTeaser) => {
        this.brainTeaser = brainTeaser;
        console.log(this.brainTeaser);
        this.brainTeaserId = brainTeaser.id;
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

  approveAnswer(id: number): void {
    const approve: BrainTeaserRequest = {
      userId: this.userId,
      brainTeaserID: id
    };
    console.log(id);
    this.service.approveAnswer(approve).subscribe((response) => {

    });
    this.isApproved = true;
    this.refreshPage();
    window.location.reload();
  }

  toggleDisplayWinner(id: number): void {
    const winner: BrainTeaserRequest = {
      userId: this.userId,
      brainTeaserID: id
    };
    console.log(id);
    this.service.displayWinner(winner).subscribe((response) => {

    });
    this.isDisplayed = true;
    this.refreshPage();
    window.location.reload();
  }
  getUrl(slug: number): string {
    return `/brain-teaser/${slug}`;
  }
}
