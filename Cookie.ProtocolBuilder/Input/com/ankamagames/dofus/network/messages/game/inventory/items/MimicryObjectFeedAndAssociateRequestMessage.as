package com.ankamagames.dofus.network.messages.game.inventory.items
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class MimicryObjectFeedAndAssociateRequestMessage extends SymbioticObjectAssociateRequestMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6460;
       
      
      private var _isInitialized:Boolean = false;
      
      public var foodUID:uint = 0;
      
      public var foodPos:uint = 0;
      
      public var preview:Boolean = false;
      
      public function MimicryObjectFeedAndAssociateRequestMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6460;
      }
      
      public function initMimicryObjectFeedAndAssociateRequestMessage(param1:uint = 0, param2:uint = 0, param3:uint = 0, param4:uint = 0, param5:uint = 0, param6:uint = 0, param7:Boolean = false) : MimicryObjectFeedAndAssociateRequestMessage
      {
         super.initSymbioticObjectAssociateRequestMessage(param1,param2,param3,param4);
         this.foodUID = param5;
         this.foodPos = param6;
         this.preview = param7;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.foodUID = 0;
         this.foodPos = 0;
         this.preview = false;
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_MimicryObjectFeedAndAssociateRequestMessage(param1);
      }
      
      public function serializeAs_MimicryObjectFeedAndAssociateRequestMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_SymbioticObjectAssociateRequestMessage(param1);
         if(this.foodUID < 0)
         {
            throw new Error("Forbidden value (" + this.foodUID + ") on element foodUID.");
         }
         param1.writeVarInt(this.foodUID);
         if(this.foodPos < 0 || this.foodPos > 255)
         {
            throw new Error("Forbidden value (" + this.foodPos + ") on element foodPos.");
         }
         param1.writeByte(this.foodPos);
         param1.writeBoolean(this.preview);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_MimicryObjectFeedAndAssociateRequestMessage(param1);
      }
      
      public function deserializeAs_MimicryObjectFeedAndAssociateRequestMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._foodUIDFunc(param1);
         this._foodPosFunc(param1);
         this._previewFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_MimicryObjectFeedAndAssociateRequestMessage(param1);
      }
      
      public function deserializeAsyncAs_MimicryObjectFeedAndAssociateRequestMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._foodUIDFunc);
         param1.addChild(this._foodPosFunc);
         param1.addChild(this._previewFunc);
      }
      
      private function _foodUIDFunc(param1:ICustomDataInput) : void
      {
         this.foodUID = param1.readVarUhInt();
         if(this.foodUID < 0)
         {
            throw new Error("Forbidden value (" + this.foodUID + ") on element of MimicryObjectFeedAndAssociateRequestMessage.foodUID.");
         }
      }
      
      private function _foodPosFunc(param1:ICustomDataInput) : void
      {
         this.foodPos = param1.readUnsignedByte();
         if(this.foodPos < 0 || this.foodPos > 255)
         {
            throw new Error("Forbidden value (" + this.foodPos + ") on element of MimicryObjectFeedAndAssociateRequestMessage.foodPos.");
         }
      }
      
      private function _previewFunc(param1:ICustomDataInput) : void
      {
         this.preview = param1.readBoolean();
      }
   }
}
