package com.ankamagames.dofus.network.types.game.character.alignment
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class ActorExtendedAlignmentInformations extends ActorAlignmentInformations implements INetworkType
   {
      
      public static const protocolId:uint = 202;
       
      
      public var honor:uint = 0;
      
      public var honorGradeFloor:uint = 0;
      
      public var honorNextGradeFloor:uint = 0;
      
      public var aggressable:uint = 0;
      
      public function ActorExtendedAlignmentInformations()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 202;
      }
      
      public function initActorExtendedAlignmentInformations(param1:int = 0, param2:uint = 0, param3:uint = 0, param4:Number = 0, param5:uint = 0, param6:uint = 0, param7:uint = 0, param8:uint = 0) : ActorExtendedAlignmentInformations
      {
         super.initActorAlignmentInformations(param1,param2,param3,param4);
         this.honor = param5;
         this.honorGradeFloor = param6;
         this.honorNextGradeFloor = param7;
         this.aggressable = param8;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.honor = 0;
         this.honorGradeFloor = 0;
         this.honorNextGradeFloor = 0;
         this.aggressable = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_ActorExtendedAlignmentInformations(param1);
      }
      
      public function serializeAs_ActorExtendedAlignmentInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_ActorAlignmentInformations(param1);
         if(this.honor < 0 || this.honor > 20000)
         {
            throw new Error("Forbidden value (" + this.honor + ") on element honor.");
         }
         param1.writeVarShort(this.honor);
         if(this.honorGradeFloor < 0 || this.honorGradeFloor > 20000)
         {
            throw new Error("Forbidden value (" + this.honorGradeFloor + ") on element honorGradeFloor.");
         }
         param1.writeVarShort(this.honorGradeFloor);
         if(this.honorNextGradeFloor < 0 || this.honorNextGradeFloor > 20000)
         {
            throw new Error("Forbidden value (" + this.honorNextGradeFloor + ") on element honorNextGradeFloor.");
         }
         param1.writeVarShort(this.honorNextGradeFloor);
         param1.writeByte(this.aggressable);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ActorExtendedAlignmentInformations(param1);
      }
      
      public function deserializeAs_ActorExtendedAlignmentInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._honorFunc(param1);
         this._honorGradeFloorFunc(param1);
         this._honorNextGradeFloorFunc(param1);
         this._aggressableFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ActorExtendedAlignmentInformations(param1);
      }
      
      public function deserializeAsyncAs_ActorExtendedAlignmentInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._honorFunc);
         param1.addChild(this._honorGradeFloorFunc);
         param1.addChild(this._honorNextGradeFloorFunc);
         param1.addChild(this._aggressableFunc);
      }
      
      private function _honorFunc(param1:ICustomDataInput) : void
      {
         this.honor = param1.readVarUhShort();
         if(this.honor < 0 || this.honor > 20000)
         {
            throw new Error("Forbidden value (" + this.honor + ") on element of ActorExtendedAlignmentInformations.honor.");
         }
      }
      
      private function _honorGradeFloorFunc(param1:ICustomDataInput) : void
      {
         this.honorGradeFloor = param1.readVarUhShort();
         if(this.honorGradeFloor < 0 || this.honorGradeFloor > 20000)
         {
            throw new Error("Forbidden value (" + this.honorGradeFloor + ") on element of ActorExtendedAlignmentInformations.honorGradeFloor.");
         }
      }
      
      private function _honorNextGradeFloorFunc(param1:ICustomDataInput) : void
      {
         this.honorNextGradeFloor = param1.readVarUhShort();
         if(this.honorNextGradeFloor < 0 || this.honorNextGradeFloor > 20000)
         {
            throw new Error("Forbidden value (" + this.honorNextGradeFloor + ") on element of ActorExtendedAlignmentInformations.honorNextGradeFloor.");
         }
      }
      
      private function _aggressableFunc(param1:ICustomDataInput) : void
      {
         this.aggressable = param1.readByte();
         if(this.aggressable < 0)
         {
            throw new Error("Forbidden value (" + this.aggressable + ") on element of ActorExtendedAlignmentInformations.aggressable.");
         }
      }
   }
}
