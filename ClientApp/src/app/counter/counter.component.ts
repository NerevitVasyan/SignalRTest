import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';

@Component({
	selector: 'app-counter-component',
	templateUrl: './counter.component.html'
})
export class CounterComponent implements OnInit {

	private hubConnection: HubConnection;

	public currentCount = 0;

	constructor(private http: HttpClient,
		@Inject('BASE_URL') private baseUrl: string) {

	}

	ngOnInit(): void {

		this.http.get(this.baseUrl + 'api/Counter').subscribe((res: any) => {
			this.currentCount = res.count;
		});

		this.hubConnection = new HubConnectionBuilder().withUrl('/hubs/counter').build();
		this.hubConnection
			.start()
			.then(() => console.log('Connection started!'))
			.catch(err => console.log('Error while establishing connection :('));

		this.hubConnection.on("Count", (res: any) => {
			this.currentCount = res.count;
		});

	}

	public incrementCounter() {
		this.http.post(this.baseUrl + 'api/Counter', null).subscribe((res: any) => {
			console.log(res);
		});
	}
}
