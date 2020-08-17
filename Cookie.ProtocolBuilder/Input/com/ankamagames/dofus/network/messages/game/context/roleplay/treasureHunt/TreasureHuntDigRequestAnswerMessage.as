package com.ankamagames.dofus.network.messages.game.context.roleplay.treasureHunt
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class TreasureHuntDigRequestAnswerMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6484;
       
      
      private var _isInitialized:Boolean = false;
      
      public var questType:uint = 0;
      
      public var result:uint = 0;
      
      public function TreasureHuntDigRequestAnswerMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6484;
      }
      
      public function initTreasureHuntDigRequestAnswerMessage(param1:uint = 0, param2:uint = 0) : TreasureHuntDigRequestAnswerMessage
      {
         this.questType = param1;
         this.result = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.questType = 0;
         this.result = 0;
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
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_TreasureHuntDigRequestAnswerMessage(param1);
      }
      
      public function serializeAs_TreasureHuntDigRequestAnswerMessage(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.questType);
         param1.writeByte(this.result);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_TreasureHuntDigRequestAnswerMessage(param1);
      }
      
      public function deserializeAs_TreasureHuntDigRequestAnswerMessage(param1:ICustomDataInput) : void
      {
         this._questTypeFunc(param1);
         this._resultFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_TreasureHuntDigRequestAnswerMessage(param1);
      }
      
      public function deserializeAsyncAs_TreasureHuntDigRequestAnswerMessage(param1:FuncTree) : void
      {
         param1.addChild(this._questTypeFunc);
         param1.addChild(this._resultFunc);
      }
      
      private function _questTypeFunc(param1:ICustomDataInput) : void
      {
         this.questType = param1.readByte();
         if(this.questType < 0)
         {
            throw new Error("Forbidden value (" + this.questType + ") on element of TreasureHuntDigRequestAnswerMessage.questType.");
         }
      }
      
      private function _resultFunc(param1:ICustomDataInput) : void
      {
         this.result = param1.readByte();
         if(this.result < 0)
         {
            throw new Error("Forbidden value (" + this.result + ") on element of TreasureHuntDigRequestAnswerMessage.result.");
         }
      }
   }
}
