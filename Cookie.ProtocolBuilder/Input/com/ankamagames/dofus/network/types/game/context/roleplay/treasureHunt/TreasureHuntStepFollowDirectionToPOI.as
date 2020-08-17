package com.ankamagames.dofus.network.types.game.context.roleplay.treasureHunt
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class TreasureHuntStepFollowDirectionToPOI extends TreasureHuntStep implements INetworkType
   {
      
      public static const protocolId:uint = 461;
       
      
      public var direction:uint = 1;
      
      public var poiLabelId:uint = 0;
      
      public function TreasureHuntStepFollowDirectionToPOI()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 461;
      }
      
      public function initTreasureHuntStepFollowDirectionToPOI(param1:uint = 1, param2:uint = 0) : TreasureHuntStepFollowDirectionToPOI
      {
         this.direction = param1;
         this.poiLabelId = param2;
         return this;
      }
      
      override public function reset() : void
      {
         this.direction = 1;
         this.poiLabelId = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_TreasureHuntStepFollowDirectionToPOI(param1);
      }
      
      public function serializeAs_TreasureHuntStepFollowDirectionToPOI(param1:ICustomDataOutput) : void
      {
         super.serializeAs_TreasureHuntStep(param1);
         param1.writeByte(this.direction);
         if(this.poiLabelId < 0)
         {
            throw new Error("Forbidden value (" + this.poiLabelId + ") on element poiLabelId.");
         }
         param1.writeVarShort(this.poiLabelId);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_TreasureHuntStepFollowDirectionToPOI(param1);
      }
      
      public function deserializeAs_TreasureHuntStepFollowDirectionToPOI(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._directionFunc(param1);
         this._poiLabelIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_TreasureHuntStepFollowDirectionToPOI(param1);
      }
      
      public function deserializeAsyncAs_TreasureHuntStepFollowDirectionToPOI(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._directionFunc);
         param1.addChild(this._poiLabelIdFunc);
      }
      
      private function _directionFunc(param1:ICustomDataInput) : void
      {
         this.direction = param1.readByte();
         if(this.direction < 0)
         {
            throw new Error("Forbidden value (" + this.direction + ") on element of TreasureHuntStepFollowDirectionToPOI.direction.");
         }
      }
      
      private function _poiLabelIdFunc(param1:ICustomDataInput) : void
      {
         this.poiLabelId = param1.readVarUhShort();
         if(this.poiLabelId < 0)
         {
            throw new Error("Forbidden value (" + this.poiLabelId + ") on element of TreasureHuntStepFollowDirectionToPOI.poiLabelId.");
         }
      }
   }
}
