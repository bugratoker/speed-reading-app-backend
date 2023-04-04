resource "aws_vpc" "project_ecs" {
  cidr_block           = var.cidr
  enable_dns_hostnames = true
  enable_dns_support   = true
  tags                 = merge(var.common_tags)
}

resource "aws_subnet" "private_east_a" {
  vpc_id            = aws_vpc.project_ecs.id
  cidr_block        = var.private_cidr_a
  availability_zone = var.region_a
  tags              = merge(var.common_tags)
}

resource "aws_subnet" "private_east_b" {
  vpc_id            = aws_vpc.project_ecs.id
  cidr_block        = var.private_cidr_b
  availability_zone = var.region_b
  tags              = merge(var.common_tags)
}

resource "aws_db_subnet_group" "default" {
  name       = "main"
  subnet_ids = [aws_subnet.private_east_b.id, aws_subnet.private_east_a.id]
  tags       = merge(var.common_tags)
}
