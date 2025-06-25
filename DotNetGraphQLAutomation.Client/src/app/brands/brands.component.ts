import { Component } from '@angular/core';
import { BrandService } from './brand.service';
import { DialogModule } from 'primeng/dialog';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService, MessageService } from 'primeng/api';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-brands',
  standalone: true,
  imports: [CommonModule, FormsModule, DialogModule, TableModule, ButtonModule, InputTextModule, ConfirmDialogModule],
  providers: [ConfirmationService, MessageService],
  templateUrl: './brands.component.html',
  styleUrl: './brands.component.scss'
})
export class BrandsComponent {
  brands: any[] = [];
  selectedBrand: any = null;
  displayDialog = false;
  isEdit = false;
  loading = false;

  constructor(
    private brandService: BrandService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService
  ) {
    this.loadBrands();
  }

  loadBrands() {
    this.loading = true;
    this.brandService.getAllBrands().subscribe(result => {
      this.brands = result.data?.brands.nodes || [];
      this.loading = false;
    });
  }

  openNew() {
    this.selectedBrand = { brandName: '', status: true, remark: '' };
    this.isEdit = false;
    this.displayDialog = true;
  }

  editBrand(brand: any) {
    this.selectedBrand = { ...brand };
    this.isEdit = true;
    this.displayDialog = true;
  }

  saveBrand() {
    if (this.isEdit) {
      this.brandService.updateBrand(this.selectedBrand).subscribe(() => {
        this.loadBrands();
        this.displayDialog = false;
      });
    } else {
      this.brandService.createBrand(this.selectedBrand).subscribe(() => {
        this.loadBrands();
        this.displayDialog = false;
      });
    }
  }

  confirmDelete(brand: any) {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete this brand?',
      accept: () => {
        this.deleteBrand(brand);
      }
    });
  }

  deleteBrand(brand: any) {
    this.brandService.deleteBrand(brand.brandId).subscribe(() => {
      this.loadBrands();
    });
  }
}
