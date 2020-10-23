import { Component, OnInit } from '@angular/core';
import { TrafficUpdateService } from '../../services/traffic-update.service';
import { TrafficUpdate } from '../../models/';

@Component({
  selector: 'app-traffic-update',
  templateUrl: './traffic-update.component.html',
  styleUrls: ['./traffic-update.component.scss'],
})
export class TrafficUpdateComponent implements OnInit {
  trafficUpdates: TrafficUpdate[];

  constructor(private service: TrafficUpdateService) { }

  ngOnInit(): void {
    this.service.getAll().subscribe((trafficUpdates) => {
      this.trafficUpdates = trafficUpdates;
      console.log(trafficUpdates);
    });
  }

  getUrl(slug: string): string {
    return `/traffic_updates/${slug}`;
  }
}
