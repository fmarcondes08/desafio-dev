import { Component, Input, OnInit, Pipe } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {
  @Input() set data(_list:any[]){
    this.list =_list;
  };

  list:any = []
  displayedColumns: string[] = ['type', 'date', 'value', 'cpf', 'card', 'hour', 'storeOwner', 'storeName'];
  dataSource = new MatTableDataSource(this.list);
  constructor() { }

  ngOnInit(): void {
  }

}
