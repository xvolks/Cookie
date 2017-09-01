package com.ankamagames.dofus.network.types.game.interactive
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class StatedElement implements INetworkType
   {
      
      public static const protocolId:uint = 108;
       
      
      public var elementId:uint = 0;
      
      public var elementCellId:uint = 0;
      
      public var elementState:uint = 0;
      
      public var onCurrentMap:Boolean = false;
      
      public function StatedElement()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 108;
      }
      
      public function initStatedElement(param1:uint = 0, param2:uint = 0, param3:uint = 0, param4:Boolean = false) : StatedElement
      {
         this.elementId = param1;
         this.elementCellId = param2;
         this.elementState = param3;
         this.onCurrentMap = param4;
         return this;
      }
      
      public function reset() : void
      {
         this.elementId = 0;
         this.elementCellId = 0;
         this.elementState = 0;
         this.onCurrentMap = false;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_StatedElement(param1);
      }
      
      public function serializeAs_StatedElement(param1:ICustomDataOutput) : void
      {
         if(this.elementId < 0)
         {
            throw new Error("Forbidden value (" + this.elementId + ") on element elementId.");
         }
         param1.writeInt(this.elementId);
         if(this.elementCellId < 0 || this.elementCellId > 559)
         {
            throw new Error("Forbidden value (" + this.elementCellId + ") on element elementCellId.");
         }
         param1.writeVarShort(this.elementCellId);
         if(this.elementState < 0)
         {
            throw new Error("Forbidden value (" + this.elementState + ") on element elementState.");
         }
         param1.writeVarInt(this.elementState);
         param1.writeBoolean(this.onCurrentMap);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_StatedElement(param1);
      }
      
      public function deserializeAs_StatedElement(param1:ICustomDataInput) : void
      {
         this._elementIdFunc(param1);
         this._elementCellIdFunc(param1);
         this._elementStateFunc(param1);
         this._onCurrentMapFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_StatedElement(param1);
      }
      
      public function deserializeAsyncAs_StatedElement(param1:FuncTree) : void
      {
         param1.addChild(this._elementIdFunc);
         param1.addChild(this._elementCellIdFunc);
         param1.addChild(this._elementStateFunc);
         param1.addChild(this._onCurrentMapFunc);
      }
      
      private function _elementIdFunc(param1:ICustomDataInput) : void
      {
         this.elementId = param1.readInt();
         if(this.elementId < 0)
         {
            throw new Error("Forbidden value (" + this.elementId + ") on element of StatedElement.elementId.");
         }
      }
      
      private function _elementCellIdFunc(param1:ICustomDataInput) : void
      {
         this.elementCellId = param1.readVarUhShort();
         if(this.elementCellId < 0 || this.elementCellId > 559)
         {
            throw new Error("Forbidden value (" + this.elementCellId + ") on element of StatedElement.elementCellId.");
         }
      }
      
      private function _elementStateFunc(param1:ICustomDataInput) : void
      {
         this.elementState = param1.readVarUhInt();
         if(this.elementState < 0)
         {
            throw new Error("Forbidden value (" + this.elementState + ") on element of StatedElement.elementState.");
         }
      }
      
      private function _onCurrentMapFunc(param1:ICustomDataInput) : void
      {
         this.onCurrentMap = param1.readBoolean();
      }
   }
}
