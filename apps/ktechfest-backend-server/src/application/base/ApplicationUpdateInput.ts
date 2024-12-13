/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { InputType, Field } from "@nestjs/graphql";
import { ApiProperty } from "@nestjs/swagger";
import { JobWhereUniqueInput } from "../../job/base/JobWhereUniqueInput";
import { ValidateNested, IsOptional, IsEnum } from "class-validator";
import { Type } from "class-transformer";
import { StaffAgencyWhereUniqueInput } from "../../staffAgency/base/StaffAgencyWhereUniqueInput";
import { EnumApplicationStatus } from "./EnumApplicationStatus";
import { UserWhereUniqueInput } from "../../user/base/UserWhereUniqueInput";

@InputType()
class ApplicationUpdateInput {
  @ApiProperty({
    required: false,
    type: () => JobWhereUniqueInput,
  })
  @ValidateNested()
  @Type(() => JobWhereUniqueInput)
  @IsOptional()
  @Field(() => JobWhereUniqueInput, {
    nullable: true,
  })
  job?: JobWhereUniqueInput | null;

  @ApiProperty({
    required: false,
    type: () => StaffAgencyWhereUniqueInput,
  })
  @ValidateNested()
  @Type(() => StaffAgencyWhereUniqueInput)
  @IsOptional()
  @Field(() => StaffAgencyWhereUniqueInput, {
    nullable: true,
  })
  staffAgency?: StaffAgencyWhereUniqueInput | null;

  @ApiProperty({
    required: false,
    enum: EnumApplicationStatus,
  })
  @IsEnum(EnumApplicationStatus)
  @IsOptional()
  @Field(() => EnumApplicationStatus, {
    nullable: true,
  })
  status?: "Option1" | null;

  @ApiProperty({
    required: false,
    type: () => UserWhereUniqueInput,
  })
  @ValidateNested()
  @Type(() => UserWhereUniqueInput)
  @IsOptional()
  @Field(() => UserWhereUniqueInput, {
    nullable: true,
  })
  user?: UserWhereUniqueInput | null;
}

export { ApplicationUpdateInput as ApplicationUpdateInput };
