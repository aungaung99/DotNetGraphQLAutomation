import { gql } from 'apollo-angular';

export const GET_ALL_BRANDS = gql`
  query GetAllBrands($first: Int, $after: String) {
    brands(first: $first, after: $after) {
      edges {
        node {
          brandId
          brandName
          status
          remark
        }
        cursor
      }
      nodes {
        brandId
        brandName
        status
        remark
      }
      pageInfo {
        hasNextPage
        hasPreviousPage
        endCursor
      }
    }
  }
`;

export const GET_BRAND_BY_ID = gql`
  query GetBrandById($id: Int!) {
    brandById(id: $id) {
      brandId
      brandName
      status
      remark
    }
  }
`;

export const CREATE_BRAND = gql`
  mutation CreateBrand($input: BrandInput!) {
    createBrand(input: $input) {
      response {
        en
        mm
      }
    }
  }
`;

export const UPDATE_BRAND = gql`
  mutation UpdateBrand($input: UpdateBrandInput!) {
    updateBrand(input: $input) {
      response {
        en
        mm
      }
    }
  }
`;

export const DELETE_BRAND = gql`
  mutation DeleteBrand($id: Int!) {
    deleteBrand(id: $id) {
      response {
        en
        mm
      }
    }
  }
`;
