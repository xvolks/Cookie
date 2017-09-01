package com.ankamagames.dofus.network.messages.game.context
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GameContextRemoveMultipleElementsMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 252;
       
      
      private var _isInitialized:Boolean = false;
      
      public var elementsIds:Vector.<Number>;
      
      private var _elementsIdstree:FuncTree;
      
      public function GameContextRemoveMultipleElementsMessage()
      {
         this.elementsIds = new Vector.<Number>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 252;
      }
      
      public function initGameContextRemoveMultipleElementsMessage(param1:Vector.<Number> = null) : GameContextRemoveMultipleElementsMessage
      {
         this.elementsIds = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.elementsIds = new Vector.<Number>();
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
         this.serializeAs_GameContextRemoveMultipleElementsMessage(param1);
      }
      
      public function serializeAs_GameContextRemoveMultipleElementsMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.elementsIds.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.elementsIds.length)
         {
            if(this.elementsIds[_loc2_] < -9007199254740990 || this.elementsIds[_loc2_] > 9007199254740990)
            {
               throw new Error("Forbidden value (" + this.elementsIds[_loc2_] + ") on element 1 (starting at 1) of elementsIds.");
            }
            param1.writeDouble(this.elementsIds[_loc2_]);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameContextRemoveMultipleElementsMessage(param1);
      }
      
      public function deserializeAs_GameContextRemoveMultipleElementsMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:Number = NaN;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readDouble();
            if(_loc4_ < -9007199254740990 || _loc4_ > 9007199254740990)
            {
               throw new Error("Forbidden value (" + _loc4_ + ") on elements of elementsIds.");
            }
            this.elementsIds.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameContextRemoveMultipleElementsMessage(param1);
      }
      
      public function deserializeAsyncAs_GameContextRemoveMultipleElementsMessage(param1:FuncTree) : void
      {
         this._elementsIdstree = param1.addChild(this._elementsIdstreeFunc);
      }
      
      private function _elementsIdstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._elementsIdstree.addChild(this._elementsIdsFunc);
            _loc3_++;
         }
      }
      
      private function _elementsIdsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:Number = param1.readDouble();
         if(_loc2_ < -9007199254740990 || _loc2_ > 9007199254740990)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of elementsIds.");
         }
         this.elementsIds.push(_loc2_);
      }
   }
}
