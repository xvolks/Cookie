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
   public class TreasureHuntFlagRequestAnswerMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6507;
       
      
      private var _isInitialized:Boolean = false;
      
      public var questType:uint = 0;
      
      public var result:uint = 0;
      
      public var index:uint = 0;
      
      public function TreasureHuntFlagRequestAnswerMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6507;
      }
      
      public function initTreasureHuntFlagRequestAnswerMessage(param1:uint = 0, param2:uint = 0, param3:uint = 0) : TreasureHuntFlagRequestAnswerMessage
      {
         this.questType = param1;
         this.result = param2;
         this.index = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.questType = 0;
         this.result = 0;
         this.index = 0;
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
         this.serializeAs_TreasureHuntFlagRequestAnswerMessage(param1);
      }
      
      public function serializeAs_TreasureHuntFlagRequestAnswerMessage(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.questType);
         param1.writeByte(this.result);
         if(this.index < 0)
         {
            throw new Error("Forbidden value (" + this.index + ") on element index.");
         }
         param1.writeByte(this.index);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_TreasureHuntFlagRequestAnswerMessage(param1);
      }
      
      public function deserializeAs_TreasureHuntFlagRequestAnswerMessage(param1:ICustomDataInput) : void
      {
         this._questTypeFunc(param1);
         this._resultFunc(param1);
         this._indexFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_TreasureHuntFlagRequestAnswerMessage(param1);
      }
      
      public function deserializeAsyncAs_TreasureHuntFlagRequestAnswerMessage(param1:FuncTree) : void
      {
         param1.addChild(this._questTypeFunc);
         param1.addChild(this._resultFunc);
         param1.addChild(this._indexFunc);
      }
      
      private function _questTypeFunc(param1:ICustomDataInput) : void
      {
         this.questType = param1.readByte();
         if(this.questType < 0)
         {
            throw new Error("Forbidden value (" + this.questType + ") on element of TreasureHuntFlagRequestAnswerMessage.questType.");
         }
      }
      
      private function _resultFunc(param1:ICustomDataInput) : void
      {
         this.result = param1.readByte();
         if(this.result < 0)
         {
            throw new Error("Forbidden value (" + this.result + ") on element of TreasureHuntFlagRequestAnswerMessage.result.");
         }
      }
      
      private function _indexFunc(param1:ICustomDataInput) : void
      {
         this.index = param1.readByte();
         if(this.index < 0)
         {
            throw new Error("Forbidden value (" + this.index + ") on element of TreasureHuntFlagRequestAnswerMessage.index.");
         }
      }
   }
}
