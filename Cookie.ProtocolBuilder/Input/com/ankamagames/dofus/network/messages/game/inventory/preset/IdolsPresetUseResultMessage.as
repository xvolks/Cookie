package com.ankamagames.dofus.network.messages.game.inventory.preset
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class IdolsPresetUseResultMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6614;
       
      
      private var _isInitialized:Boolean = false;
      
      public var presetId:uint = 0;
      
      public var code:uint = 3;
      
      public var missingIdols:Vector.<uint>;
      
      private var _missingIdolstree:FuncTree;
      
      public function IdolsPresetUseResultMessage()
      {
         this.missingIdols = new Vector.<uint>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6614;
      }
      
      public function initIdolsPresetUseResultMessage(param1:uint = 0, param2:uint = 3, param3:Vector.<uint> = null) : IdolsPresetUseResultMessage
      {
         this.presetId = param1;
         this.code = param2;
         this.missingIdols = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.presetId = 0;
         this.code = 3;
         this.missingIdols = new Vector.<uint>();
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
         this.serializeAs_IdolsPresetUseResultMessage(param1);
      }
      
      public function serializeAs_IdolsPresetUseResultMessage(param1:ICustomDataOutput) : void
      {
         if(this.presetId < 0)
         {
            throw new Error("Forbidden value (" + this.presetId + ") on element presetId.");
         }
         param1.writeByte(this.presetId);
         param1.writeByte(this.code);
         param1.writeShort(this.missingIdols.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.missingIdols.length)
         {
            if(this.missingIdols[_loc2_] < 0)
            {
               throw new Error("Forbidden value (" + this.missingIdols[_loc2_] + ") on element 3 (starting at 1) of missingIdols.");
            }
            param1.writeVarShort(this.missingIdols[_loc2_]);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_IdolsPresetUseResultMessage(param1);
      }
      
      public function deserializeAs_IdolsPresetUseResultMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:uint = 0;
         this._presetIdFunc(param1);
         this._codeFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readVarUhShort();
            if(_loc4_ < 0)
            {
               throw new Error("Forbidden value (" + _loc4_ + ") on elements of missingIdols.");
            }
            this.missingIdols.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_IdolsPresetUseResultMessage(param1);
      }
      
      public function deserializeAsyncAs_IdolsPresetUseResultMessage(param1:FuncTree) : void
      {
         param1.addChild(this._presetIdFunc);
         param1.addChild(this._codeFunc);
         this._missingIdolstree = param1.addChild(this._missingIdolstreeFunc);
      }
      
      private function _presetIdFunc(param1:ICustomDataInput) : void
      {
         this.presetId = param1.readByte();
         if(this.presetId < 0)
         {
            throw new Error("Forbidden value (" + this.presetId + ") on element of IdolsPresetUseResultMessage.presetId.");
         }
      }
      
      private function _codeFunc(param1:ICustomDataInput) : void
      {
         this.code = param1.readByte();
         if(this.code < 0)
         {
            throw new Error("Forbidden value (" + this.code + ") on element of IdolsPresetUseResultMessage.code.");
         }
      }
      
      private function _missingIdolstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._missingIdolstree.addChild(this._missingIdolsFunc);
            _loc3_++;
         }
      }
      
      private function _missingIdolsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readVarUhShort();
         if(_loc2_ < 0)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of missingIdols.");
         }
         this.missingIdols.push(_loc2_);
      }
   }
}
